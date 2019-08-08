namespace CustomActions.Utils
{
  using Microsoft.Deployment.WindowsInstaller;


  internal class CryptorWrapper
  {
    private readonly Session m_session;

    internal CryptorWrapper(Session session)
    {
      m_session = session;
    }

    internal string ResultUser { get; private set; }
    internal string ResultPassword { get; private set; }

    internal void EncryptAccountDetails(string userToEncryptProperty, string passwordToEncryptProperty)
    {
      EncryptAccountDetails(userToEncryptProperty, passwordToEncryptProperty, null);
    }

    private void EncryptAccountDetails(string userToEncryptProperty, string passwordToEncryptProperty, string domainProperty)
    {
      var userToEncrypt = m_session[userToEncryptProperty];
      var passwordToEncrypt = m_session[passwordToEncryptProperty];

      userToEncrypt = AddDomain(domainProperty, userToEncrypt);

      LogNothingToEncrypt(userToEncryptProperty, passwordToEncryptProperty, userToEncrypt, passwordToEncrypt);

      if (string.IsNullOrEmpty(userToEncrypt) || string.IsNullOrEmpty(passwordToEncrypt))
      {
        return;
      }
      ResultUser = AUM.Core.Cryptor.Encrypt(userToEncrypt);
      ResultPassword = AUM.Core.Cryptor.Encrypt(passwordToEncrypt, userToEncrypt);
    }

    private void LogNothingToEncrypt(string userToEncryptProperty, string passwordToEncryptProperty, string userToEncrypt, string passwordToEncrypt)
    {
      if (string.IsNullOrEmpty(userToEncrypt))
      {
        m_session.Log("Nothing to encrypt! Put user name to property \"{0}\"", userToEncryptProperty);
      }

      if (string.IsNullOrEmpty(passwordToEncrypt))
      {
        m_session.Log("Nothing to encrypt! Put password to property \"{0}\"", passwordToEncryptProperty);
      }
    }

    private string AddDomain(string domainProperty, string userToEncrypt)
    {
      if (string.IsNullOrEmpty(domainProperty))
      {
        return userToEncrypt;
      }

      var domain = m_session[domainProperty];
      userToEncrypt = new LoginWrapper(domain, userToEncrypt).FullName;
      return userToEncrypt;
    }

    internal void DecryptAccountDetails(string userToDecryptProperty, string passwordToDecryptProperty)
    {
      var userToDecrypt = m_session[userToDecryptProperty];
      var passwordToDecrypt = m_session[passwordToDecryptProperty];

      LogNothingToDecrypt(userToDecryptProperty, passwordToDecryptProperty, userToDecrypt, passwordToDecrypt);

      if (string.IsNullOrEmpty(userToDecrypt) || string.IsNullOrEmpty(passwordToDecrypt))
      {
        return;
      }
      var user = AUM.Core.Cryptor.Decrypt(userToDecrypt);
      ResultUser = user;
      if (!string.IsNullOrEmpty(user))
      {
        ResultPassword = AUM.Core.Cryptor.Decrypt(passwordToDecrypt, user);
      }
    }

    private void LogNothingToDecrypt(string userToDecryptProperty, string passwordToDecryptProperty, string userToDecrypt, string passwordToDecrypt)
    {
      if (string.IsNullOrEmpty(userToDecrypt))
      {
        m_session.Log("Nothing to decrypt! Put encrypted user name to property \"{0}\"", userToDecryptProperty);
      }

      if (string.IsNullOrEmpty(passwordToDecrypt))
      {
        m_session.Log("Nothing to decrypt! Put encrypted password to property \"{0}\"", passwordToDecryptProperty);
      }
    }
  }
}