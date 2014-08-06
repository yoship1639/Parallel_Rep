using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Parallel_Rep
{
    // スレッド処理としてローカル座標にある姿勢をワールド座標に変換する
    // 行列を姿勢行列と見立てて、拡大、回転(X,Y,Z)、移動の5回の行列演算を行う
    class TP_MatrixTransform :
        IThreadProcess
    {
        static readonly Matrix Scale = Matrix.MakeScale(1, 1, 3);               // Z方向に3倍拡大
        static readonly Matrix RotateY = Matrix.MakeRotateY(Math.PI / 4);       // Y軸に対して90度回転
        static readonly Matrix RotateZ = Matrix.MakeRotateZ(Math.PI / 3);       // Z軸に対して120度回転
        static readonly Matrix RotateX = Matrix.MakeRotateX(Math.PI / 2);       // X軸に対して180度回転
        static readonly Matrix Translation = Matrix.MakeTranslation(0, 10, 0);  // Y方向に10移動

        Matrix[] Transforms;                                    // 姿勢行列の配列
        Thread[] Threads;                                       // スレッドの配列

        /// <summary>
        /// 処理を行う前の初期化
        /// </summary>
        /// <param name="dataNum">データの数</param>
        /// <param name="threadNum">スレッドの数</param>
        public void Initialize(int dataNum, int threadNum)
        {
            // 姿勢行列をデータの数だけ作成
            Transforms = new Matrix[dataNum];
            for (int i = 0; i < dataNum; i++) 
                Transforms[i] = Matrix.MakeTranslation(i, 0, 0);

            // スレッドを作成
            Threads = new Thread[threadNum];
            for (int i = 0; i < threadNum; i++)
            {
                // スレッド内で行う処理
                ThreadStart ts = new ThreadStart(()=>
                {
                    int index = i;
                    while(index < dataNum)  // インデックスがデータ数を超えるまでループ
                    {
                        var m = Transforms[index];
                        m = m.Mul(Scale);       // 拡大
                        m = m.Mul(RotateY);     // Y軸回転
                        m = m.Mul(RotateZ);     // Z軸回転
                        m = m.Mul(RotateX);     // X軸回転
                        m = m.Mul(Translation); // 移動

                        Transforms[index] = m;  // 結果を代入

                        index += threadNum;     // 次に処理するインデックス
                    }
                });
                Threads[i] = new Thread(ts);
            }
        }

        /// <summary>
        /// 処理を行う
        /// </summary>
        public void StartProcess()
        {
            // スレッド開始
            foreach (var th in Threads) th.Start();

            // すべてのスレッドが終了するまで待つ
            foreach (var th in Threads) th.Join();
        }
    }

    /// <summary>
    /// 行列を表す構造体
    /// </summary>
    struct Matrix
    {
        public double[] e;     // 要素

        // 移動行列を作る
        public static Matrix MakeTranslation(double x, double y, double z)
        {
            var m = Identity;
            m.e[12] = x;
            m.e[13] = y;
            m.e[14] = z;

            return m;
        }

        // X軸の回転行列を作る
        public static Matrix MakeRotateX(double radian)
        {
            var m = Identity;
            var sin = Math.Sin(radian);
            var cos = Math.Cos(radian);

            m.e[5] = cos;
            m.e[6] = -sin;
            m.e[9] = sin;
            m.e[10] = cos;

            return m;
        }

        // Y軸の回転行列を作る
        public static Matrix MakeRotateY(double radian)
        {
            var m = Identity;
            var sin = Math.Sin(radian);
            var cos = Math.Cos(radian);

            m.e[0] = cos;
            m.e[2] = sin;
            m.e[8] = -sin;
            m.e[10] = cos;

            return m;
        }

        // Z軸の回転行列を作る
        public static Matrix MakeRotateZ(double radian)
        {
            var m = Identity;
            var sin = Math.Sin(radian);
            var cos = Math.Cos(radian);

            m.e[0] = cos;
            m.e[1] = -sin;
            m.e[4] = sin;
            m.e[5] = cos;

            return m;
        }

        // 拡大行列を作る
        public static Matrix MakeScale(double sx, double sy, double sz)
        {
            var m = Identity;

            m.e[0] = sx;
            m.e[5] = sy;
            m.e[10] = sz;

            return m;
        }

        // 掛け算を行う
        public Matrix Mul(Matrix m)
        {
            Matrix res = Identity;

            for (int y = 0; y < 4; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    res.e[y * 4 + x] = 
                        e[y * 4] * m.e[x] + 
                        e[y * 4 + 1] * m.e[x + 4] +
                        e[y * 4 + 2] * m.e[x + 8] +
                        e[y * 4 + 3] * m.e[x + 12];
                }
            }

            return res;
        }

        // 正規化行列
        public static readonly Matrix Identity = new Matrix()
        {
            e = new double[16]
            {
                1, 0, 0, 0,
                0, 1, 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1
            },
        };
    }
}
