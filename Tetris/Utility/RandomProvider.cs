using System;
using System.Security.Cryptography;
using System.Threading;
using This = Tetris.Utility.RandomProvider;

namespace Tetris.Utility
{
    /// <summary>
    /// 提供随机数生成功能。
    /// </summary>
    public static class RandomProvider
    {
        #region プロパティ
        /// <summary>
        /// 获得每个线程独立的随机数生成功能的锁存器。
        /// </summary>
        private static ThreadLocal<Random> RandomWrapper { get; } = new ThreadLocal<Random>(() =>
        {
            //--- PCL 因为不能使用RNGCryptoServiceProvider，所以用GUID代替
            //var @byte = Guid.NewGuid().ToByteArray();
            //var seed = BitConverter.ToInt32(@byte, 0);
            //return new Random(seed);

            var @byte = new byte[sizeof(int)];
            using (var crypto = new RNGCryptoServiceProvider())
                crypto.GetBytes(@byte);
            var seed = BitConverter.ToInt32(@byte, 0);
            return new Random(seed);
        });


        /// <summary>
        /// 获得以线索为单位的独立随机数生成功能。
        /// </summary>
        public static Random ThreadRandom => This.RandomWrapper.Value;
        #endregion
    }
}
