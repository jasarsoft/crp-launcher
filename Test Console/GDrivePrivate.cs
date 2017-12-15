
namespace Test_Console
{
    internal class GDrivePrivate
    {
        StringCipher cipher;

        private readonly string nameService;
        private readonly string emailService;
        private readonly string credentialService;

        public GDrivePrivate()
        {
            cipher = new StringCipher();

            this.nameService = "2oQ4ymQQjSaSysCnvEk097pO8lptWaRazfMeat97Ez7U24YEhapu+7x+NzPlJRKfgDW1gBfgNJM3/BeTTrxiLWJ9AagyywKKBH9+bOlTNucz1NdrxSYp2GiAhibZ9ffz";
            this.emailService = "d62uEVe6V++zfqhsLhk6I5jgQ4BinfAYjuhKmxDL2MabVQer59zvlYSFREt/GkYC90oBEnddNQ6JigAv+j+pO8jcaFQ26/w4Ldb7PD1UnxiyRNULPw5gZf8Gg8mvgx4/nohQaN38ygj4wbV9zZGGjfzf1E7zJtPsBHZKvNzaFig=";
            this.credentialService = "3JQlRuRAFh22dAAeuRNGoQ9pMFAR3/Z/wvVLXrpXyirXX2VNEII6Yn1dBdll+T25dbf66Gown0MwufvCC2awLzf0BRNWB9lN1WvrDSnhEJg/fK0WkHUHpraYF8j+a66d+/0qyWNlKvsXQjN/owcF8tX7yiKtsb+sPvRJJIeOQOd3SYLtzE7AJ89DvnhLeMKKn8eUbImrDZx9MXKASI6+8A==";
        }


        public string Name
        {
            get { return cipher.Decrypt(this.nameService); }
        }

        public string Email
        {
            get { return cipher.Decrypt(emailService); }
        }

        public string Credential
        {
            get { return cipher.Decrypt(credentialService); }
        }
    }
}
