using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            // if validation is false return false ; else continue
            if (!validateUserData(firstName, lastName, email, dateOfBirth, clientId)) return false;

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);
            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
            
            if (!validateCreditLimit(user, client)) return false;

            UserDataAccess.AddUser(user);
            return true;
        }
        private bool validateUserData(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            // if any condition is false return false ; else true
            if (!validateNames(firstName, lastName) || !validateEmail(email) || !validateAge(dateOfBirth)) return false;
            return true;
        }
        private bool validateNames(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)) return false;
            return true;
        }
        private bool validateEmail(string email)
        {
            if (!email.Contains("@") && !email.Contains(".")) return false;
            return true;
        }
        private bool validateAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            if (age < 21) return false;
            return true;
        }

        private void setCreditLimit(User user, Client client)
        {
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            }
            else
            {
                user.HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
            }
        }
        private bool validateCreditLimit(User user, Client client)
        {
            setCreditLimit(user, client);
            
            if (user.HasCreditLimit && user.CreditLimit < 500) return false;
            return true;
        }
        
    }
}
