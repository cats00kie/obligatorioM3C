using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.EntityFramework
{
    public class RepositorioAdministradorEF : IRepositorioAdministrador
    {
        private PapeleriaContext _context;
        public RepositorioAdministradorEF()
        {
            this._context = new PapeleriaContext();
        }
        public bool Add(Usuario aAgregar)
        {
            try
            {
                this._context.Usuarios.Add(aAgregar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Administrador FindByEmail(string email)
        {
            return this._context.Admins.Where(admin => admin.Email == email).FirstOrDefault(); 
        }

        public bool Remove(int id)
        {
            try
            {
                Administrador aBorrar = new Administrador { Id = id };
                this._context.Admins.Remove(aBorrar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(Administrador aModificar)
        {
            try
            {
                this._context.Admins.Update(aModificar);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static readonly byte[] Salt = { 1, 2, 3, 4, 5, 6, 7, 8 }; // Random salt

        public string Encrypt(string password)
        {
            using var aesAlg = new RijndaelManaged
            {
                KeySize = 256,
                BlockSize = 128,
                Mode = CipherMode.CFB,
                Padding = PaddingMode.PKCS7
            };

            var key = new Rfc2898DeriveBytes(password, Salt, 1000).GetBytes(32);
            aesAlg.Key = key;

            using var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using var msEncrypt = new MemoryStream();
            using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
            using var swEncrypt = new StreamWriter(csEncrypt);

            swEncrypt.Write("encryption");
            swEncrypt.Flush();
            csEncrypt.FlushFinalBlock();

            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public string Decrypt(string password)
        {
            using var aesAlg = new RijndaelManaged
            {
                KeySize = 256,
                BlockSize = 128,
                Mode = CipherMode.CFB,
                Padding = PaddingMode.PKCS7
            };

            var key = new Rfc2898DeriveBytes(password, Salt, 1000).GetBytes(32);
            aesAlg.Key = key;

            var cipherTextBytes = Convert.FromBase64String("encryption");
            using var msDecrypt = new MemoryStream(cipherTextBytes);
            using var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
            using var srDecrypt = new StreamReader(csDecrypt);

            return srDecrypt.ReadToEnd();
        }
    }
}
