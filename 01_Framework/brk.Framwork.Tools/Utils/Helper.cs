namespace brk.Framework.Tools.Utils
{
    public static class Helper
    {
        /// <summary>
        /// ساخت توکن جدید
        /// </summary>
        /// <returns></returns>
        public static string GenerateToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());
            return token;
        }
    }
}
