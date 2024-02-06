namespace AppAutorG2.Views;

public partial class PageIntoAutores : ContentPage
{
	Controllers.AutoresControllers AutoresDB;
	public PageIntoAutores(Controllers.AutoresControllers dbpath)
	{
		InitializeComponent();
        AutoresDB = dbpath;
	}

    public PageIntoAutores()
    {
        InitializeComponent();
        AutoresDB = new Controllers.AutoresControllers();
    }

    async void btn_guardar_Clicked(System.Object sender, System.EventArgs e)
    {

        var aut = new Models.Autores
        {
            Nombres = nombres.Text,
            Pais = pais.SelectedItem != null ? pais.SelectedItem.ToString() : string.Empty
            

        };

        try
        {
            if (AutoresDB != null)
            {
                if (await AutoresDB.StoreAutor(aut) > 0)
                {
                    await DisplayAlert("Aviso", "Registro Almacenado", "OK");
                    //mando a llamar la vista donde tengo los eqtos para mostrar
                    //await Navigation.PushAsync(new PageMostrarAutores(AutoresDB));
                }
            }
            else
            {
                // Manejar la situación donde PersonDB es null
                await DisplayAlert("Error", $"El controlador de base de datos no está inicializado.", "OK");
            }
        }

        catch(Exception ex)
        {
            // Manejar cualquier excepción que ocurra durante el almacenamiento
            await DisplayAlert("Error", $"Ocurrió un error al almacenar el registro: {ex.Message}", "OK");

        }

    }

    async void btn_mostrar_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new PageMostrarAutores(AutoresDB));
    }
}
