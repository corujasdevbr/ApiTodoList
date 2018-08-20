using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace CorujasDev.TodoList.Util.Criptografia
{
    public static class Senha
    {
        /// <summary>
        /// Gera uma nova senha do tamanho informado
        /// </summary>
        /// <param name="TamanhoDaSenha">Tamanho da senha</param>
        /// <returns>Retorna uma senha</returns>
        public static string GerarSenha(int TamanhoDaSenha)
        {
            string validar = "abcdefghijklmnozABCDEFGHIJKLMNOZ1234567890@#$%&*!";
            try
            {
                StringBuilder strbld = new StringBuilder(100);
                Random random = new Random();
                while (0 < TamanhoDaSenha--)
                {
                    strbld.Append(validar[random.Next(validar.Length)]);
                }
                return  strbld.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Criptografa a senha informada
        /// </summary>
        /// <param name="senha">Senha a ser criptografada</param>
        /// <returns>Retorna a senha criptografada</returns>
        public static string Criptografa(string senha)
        {
            try
            {
                UnicodeEncoding encoding = new UnicodeEncoding();
                byte[] hashBytes;
                using (HashAlgorithm hash = SHA1.Create())
                    hashBytes = hash.ComputeHash(encoding.GetBytes(senha));

                StringBuilder hashValue = new StringBuilder(hashBytes.Length * 2);
                foreach (byte b in hashBytes)
                {
                    hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
                }

                return hashValue.ToString();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
