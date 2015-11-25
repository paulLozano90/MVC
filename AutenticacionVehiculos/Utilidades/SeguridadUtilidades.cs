
using System;
using System.Security.Cryptography;
using System.Text;

namespace AutenticacionVehiculos.Utilidades
{
    public class SeguridadUtilidades
    {
        public static String GetSha1(string texto)
        {
            var sha = SHA1.Create();
            UTF8Encoding encoding = new UTF8Encoding();
            //Creamos un array de bits porque la clase sha
            //nos devuelve bytes.
            byte[] datos;
            StringBuilder builer = new StringBuilder();
            //Generamos el hash. Pasandole un array de bytes
            datos = sha.ComputeHash(encoding.GetBytes(texto));
            //Transformacion a texto
            for (int i = 0; i < datos.Length; i++)
            {
                builer.AppendFormat("{0:x2}", datos[i]);
            }
            return builer.ToString();
        }

        public static byte[] GeyKey(String txt)
        {
            //Genera una password(array de btyes) desde un origen, ese
            //origen es un txt. El null es para que genere una misma clave, 
            //si no te haria uno de forma aleatoria. Da igual si da ese
            //pequeño error, porque aun se puede usar.
            return new PasswordDeriveBytes(txt,null).GetBytes(32);
        }
        public static String Cifrar(String contenido, String clave)
        {
            var encoding = new UTF8Encoding();
            var cripto = new RijndaelManaged();
            
            byte[] cifrado;
            //Contiene el uv mas el texto cifrado
            byte[] retorno;
            //Contiene una clave de la longitud indicada para poder usarlo
            byte[] key=GeyKey(clave);
            cripto.Key = key;
            //Vector de inicializador
            cripto.GenerateIV();
            //Lo que queremos encriptar lo convierte en un array de bytes
            byte[] aEncriptar = encoding.GetBytes(contenido);
            //Devuelve el contenido empezando en la posicion 0 de aEncriptar
            cifrado = cripto.CreateEncryptor().TransformFinalBlock(aEncriptar, 0, aEncriptar.Length);
            retorno = new byte[cripto.IV.Length + cifrado.Length];
            cripto.IV.CopyTo(retorno,0);
            cifrado.CopyTo(retorno,cripto.IV.Length);

            return Convert.ToBase64String(retorno);
        }
        public static String DesCifrar(byte[] contenido, String clave)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            var cripto = new RijndaelManaged();
            //Vector temporal, que le asignara un tamaño determinado
            var ivTemp = new byte[cripto.IV.Length];
            //var datos = encoding.GetBytes(contenido);
            var key = GeyKey(clave);
            var cifrado = new byte[contenido.Length-ivTemp.Length];

            cripto.Key = key;
            //Primero dices que quieres copiar
            Array.Copy(contenido,ivTemp,ivTemp.Length);
            //Va copiar desde la posicion 0 hasta que se llene
            Array.Copy(contenido,ivTemp.Length, cifrado,0,cifrado.Length);

            cripto.IV = ivTemp;
            var descifrado = cripto.CreateDecryptor().TransformFinalBlock(cifrado, 0, cifrado.Length);
            return encoding.GetString(descifrado);
        }
    }
}