using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.QueryString
{
    public class QueryString
    {
        string qscrypt;
        string qs;
        Dictionary<string, string> valores = new Dictionary<string, string>();
        public QueryString(Dictionary<string, string> valores)
        {
            if (valores.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, string> item in valores)
                {
                    sb.Append(item.Key);
                    sb.Append("=");
                    sb.Append(item.Value);
                    sb.Append("&");
                }
                sb.Remove(sb.Length - 1, 1);
                qs = sb.ToString();
                qscrypt = Convert.ToBase64String(Libreria.Seguridad.Rijndael.Encriptar(qs));
                //qscrypt = Convert.ToBase64String(HDC.Sistema.Base.Seguridad.Rijndael.Encriptar(qs));
            }
        }
        public QueryString(string qsEncriptada)
        {
            try
            {
                qsEncriptada = qsEncriptada.Replace(' ', '+');
                qsEncriptada = qsEncriptada.Replace("%2f", @"/");

                qs = Libreria.Seguridad.Rijndael.Desencriptar(Convert.FromBase64String(qsEncriptada));
                //qs = HDC.Sistema.Base.Seguridad.Rijndael.Desencriptar(Convert.FromBase64String(qsEncriptada));
                string[] arrvalores = qs.Split('&');
                foreach (string item in arrvalores)
                {
                    string[] par = item.Split('=');
                    valores.Add(par[0], par[1]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string QSEncriptada
        {
            get
            {
                if (qs != string.Empty) return qscrypt;
                return qs;
            }
        }
        public Dictionary<string, string> Valores
        {
            set
            {

                if (valores.Count == 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (KeyValuePair<string, string> item in value)
                    {
                        sb.Append(item.Key);
                        sb.Append("=");
                        sb.Append(item.Value);
                        sb.Append("&");
                    }
                    sb.Remove(sb.Length - 1, 1);
                    qs = sb.ToString();
                    qscrypt = Convert.ToBase64String(Libreria.Seguridad.Rijndael.Encriptar(qs));

                    //qscrypt = Convert.ToBase64String(HDC.Sistema.Base.Seguridad.Rijndael.Encriptar(qs));

                }
                else
                {
                    throw new Exception("Operación Inválida. El diccionario debe estar vacio.");
                }
            }
        }
        public string this[string varNomb]
        {
            get
            {
                if (valores.ContainsKey(varNomb))
                    return valores[varNomb];
                return string.Empty;
            }
        }
        public void Limpiar()
        {
            qscrypt = string.Empty;
            qs = string.Empty;
            valores.Clear();
        }
    }
}
