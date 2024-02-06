namespace AppAutorG2.Views;

public partial class PageMostrarAutores : ContentPage
{
    Controllers.AutoresControllers AutoresDB;
    List<Models.Autores> listaAutoresCompleta;

    public PageMostrarAutores(Controllers.AutoresControllers dbpath)
	{
		InitializeComponent();
        AutoresDB = dbpath;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Obtener los datos de la base de datos y asignarlos al origen de datos de tu interfaz de usuario
        // var autores = await AutoresDB.GetListAutores();
        listaAutoresCompleta = await AutoresDB.GetListAutores();

        listaAutores.ItemsSource = listaAutoresCompleta;
    }

    private void BuscarEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        string filtro = e.NewTextValue.ToLower();
        var autoresFiltrados = listaAutoresCompleta.Where(a => a.Nombres.ToLower().Contains(filtro) || a.Pais.ToLower().Contains(filtro)).ToList();
        listaAutores.ItemsSource = autoresFiltrados;
    }
}
