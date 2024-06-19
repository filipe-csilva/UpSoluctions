

namespace UpSoluctions.Web.Pages
{
    public partial class Login
    {
        //private bool success, errors;
        private string email = string.Empty;
        private string password = string.Empty;
        //private string[] errorList = [];

        //public async Task DoLoginAsync()
        //{
        //    success = errors = false;
        //    errorList = [];

        //    if (string.IsNullOrWhiteSpace(email))
        //    {
        //        errors = true;
        //        errorList = ["Email is required."];

        //        return;
        //    }

        //    if (string.IsNullOrWhiteSpace(password))
        //    {
        //        errors = true;
        //        errorList = ["Password is required."];

        //        return;
        //    }

        //    var result = await Acct.LoginAsync(email, password);

        //    if (result.Succeeded)
        //    {
        //        success = true;
        //        email = password = string.Empty;
        //    }
        //    else
        //    {
        //        errors = true;
        //        errorList = result.ErrorList;
        //    }
        //}

        public async Task DoLoginAsync()
        {
            var resposta = await authAPI.LoginAsync(email, password);
            if (resposta.Sucesso)
            {
                    navigationManager.NavigateTo("/longed");
            }
        }

        private string statusMessage;

        protected override async Task OnInitializedAsync()
        {
            await CheckStatus();
        }

        private async Task CheckStatus()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Head, "api/status");

                var response = await Http.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    statusMessage = "Request was successful.";
                }
                else
                {
                    statusMessage = $"Request failed with status code: {response.StatusCode}";
                }
            }
            catch (HttpRequestException httpRequestException)
            {
                statusMessage = $"Request error: {httpRequestException.Message}";
            }
            catch (Exception ex)
            {
                statusMessage = $"An unexpected error occurred: {ex.Message}";
            }
        }
    }
}
