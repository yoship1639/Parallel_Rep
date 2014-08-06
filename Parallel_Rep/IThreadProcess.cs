using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parallel_Rep
{
    /// <summary>
    /// 処理をスレッドにより並列で行う機能を持つインタフェース
    /// </summary>
    public interface IThreadProcess
    {
        /// <summary>
        /// 処理を行う前の初期化
        /// </summary>
        /// <param name="dataNum">データの数</param>
        /// <param name="threadNum">スレッドの数</param>
        void Initialize(int dataNum, int threadNum);

        /// <summary>
        /// 処理を行う
        /// </summary>
        void StartProcess();
    }
}
