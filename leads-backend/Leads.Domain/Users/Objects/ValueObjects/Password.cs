namespace Leads.Domain.Users.Objects.ValueObjects
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using Exceptions;
    using Infrastructure.Domain.ValueObjects.Base;


    public class Password : ValueObject
    {
        private const int SaltLength = 64;
        private static readonly HashAlgorithm HashAlgorithm = SHA512.Create();
        private static readonly RandomNumberGenerator Random = RandomNumberGenerator.Create();


        [Obsolete("Only for reflection", true)]
        public Password()
        {
        }

        public Password(string password)
        {
            CheckStrength(password);

            Salt = CreateSalt();
            Hash = ComputeHash(password, Salt);
        }


        public virtual byte[] Hash { get; protected set; }

        public virtual byte[] Salt { get; protected set; }


        public virtual bool Check(string password) => Hash.SequenceEqual(ComputeHash(password, Salt));


        private static void CheckStrength(string password)
        {
            // TODO : implement more strict password strength check

            if (string.IsNullOrWhiteSpace(password) || password.Length < 8)
                throw new PasswordIsTooWeakException();
        }

        private static byte[] CreateSalt()
        {
            byte[] salt = new byte[SaltLength];

            Random.GetBytes(salt);

            return salt;
        }

        private static byte[] ComputeHash(string password, byte[] salt)
        {
            return HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(password).Concat(salt).ToArray());
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Password anotherPassword))
                return false;

            return Hash.SequenceEqual(anotherPassword.Hash) && Salt.SequenceEqual(anotherPassword.Salt);
        }

        public override int GetHashCode()
        {
            // we assume that Password is pseudo-immutable:
            // - no Set methods (only protected set for reflection);
            // - no one will change byte[] contents

            HashCode hashCode = new HashCode();

            foreach (var b in Hash)
                hashCode.Add(b);

            foreach (var b in Salt)
                hashCode.Add(b);

            return hashCode.ToHashCode();
        }
    }
}