using AntDesign;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Shared.Models.Penalties;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.Pages.Penalties
{

    public partial class Penalties
    {
        public List<PenaltiesResponse> penaltiesResponses { get; set; } = new List<PenaltiesResponse>();
        public AddEditPenalties AddEditPenalties { get; set; } = new();

        private string error;

        string title = "Add New Penalties";
        bool _visible = false;
        private Form<AddEditPenalties> form;
        private void OnFinishFailed(EditContext editContext)
        {
            Console.WriteLine($"Failed:{JsonSerializer.Serialize(AddEditPenalties)}");
            error = "Please Check That All Required Are Entered";
            _message.Error(error, 2.5);
        }
        private void OpenModal(int Id = 0)
        {
            if (Id != 0)
            {

                var _single = penaltiesResponses.Find(x => x.Id == Id);
                title = $"Update Annual Admin Budget";
                AddEditPenalties = new AddEditPenalties(_single);
            }
            _visible = true;
        }
        private void HandleOk(MouseEventArgs e)
        {
            Console.WriteLine(e);
            _visible = false;
        }

        private void HandleCancel(MouseEventArgs e)
        {
            Console.WriteLine(e);
            _visible = false;
            AddEditPenalties = new();
        }
        bool _loading = false;

        protected override async Task OnInitializedAsync()
        {
            _loading = true;
            await LoadData();
            await base.OnInitializedAsync();
            _loading = false;
        }

        private async Task LoadData()
        {
            try
            {
                var response = await _penaltiesServiceAsync.GetAllAsync();
                if (response != null && response.Succeeded == true)
                {
                    penaltiesResponses = response.Data;
                    await _message.Info(response.Message);
                }
                else
                {
                    await _message.Error(response.Message);
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        private async Task SaveAsync()
        {
            var response = await _penaltiesServiceAsync.SaveAsync(AddEditPenalties);
            if (response.Succeeded == true)
            {
                await _message.Loading("Processing Your Request, Please wait...", 2.5)
                .ContinueWith((result) =>
                {
                    _message.Info($"{response.Message}", 2.5);

                });
                _loading = false;
                _visible = false;
                AddEditPenalties = new();
                await LoadData();
                StateHasChanged();
            }
        }
    }
}
