using System;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoAPI02.Cryptography
{
    /// <summary>
    /// Classe para criptografia de dados no padrão MD5
    /// </summary>
    public class MD5Encrypt
    {
        /// <summary>
        /// Método para criptografar um valor texto com MD5
        /// e retornar o HASH obtido da criptografia
        /// </summary>
        /// <param name="value">Valor que será criptografado</param>
        /// <returns>HASH MD5 resultante da criptografia</returns>
        public static string GetHash(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

            var result = string.Empty;

            foreach (var item in hash)
            {
                result += item.ToString("X2"); //X2 -> String hexadecimal
            }

            return result;
        }
    }
}