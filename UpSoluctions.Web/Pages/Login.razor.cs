namespace UpSoluctions.Web.Pages
{
    public partial class Login
    {
        private bool success, errors;
        private string email = string.Empty;
        private string password = string.Empty;
        private string[] errorList = [];

        public async Task DoLoginAsync()
        {
            success = errors = false;
            errorList = [];

            if (string.IsNullOrWhiteSpace(email))
            {
                errors = true;
                errorList = ["Email is required."];

                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                errors = true;
                errorList = ["Password is required."];

                return;
            }

            var result = await Acct.LoginAsync(email, password);

            if (result.Succeeded)
            {
                success = true;
                email = password = string.Empty;
            }
            else
            {
                errors = true;
                errorList = result.ErrorList;
            }
        }
    }
}
