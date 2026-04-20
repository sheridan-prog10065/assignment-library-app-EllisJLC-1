using LibraryLibrary;
using System.Collections.ObjectModel;

namespace LibraryAppInteractive;

public partial class SearchPage : ContentPage
{
    Library _library;
    Book _book;
    public SearchPage(Library library)
    {
        InitializeComponent();

        _library = library;
        _book = null;
    }

    /// <summary>
    /// Borrow a book
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public async void OnBorrowBook(object sender, EventArgs e)
    {
        try
        {
            _book.BorrowBook();

            await DisplayAlertAsync("Borrowed!", "Book has been loaed", "Ok");
        }
        catch (NullReferenceException ex)
        {
            await DisplayAlertAsync("Error", "Please select a book to loan", "Ok");
        }
    }

    public async void OnReserveBook(object sender, EventArgs e)
    {
        try
        {
            if (_book == null)
            {
                throw new ArgumentNullException("Invalid Book");
            }

            _book.ReserveBook();
        }
        catch (ArgumentNullException ex)
        {
            await DisplayAlertAsync("Error", "Please select a book", "Ok");
        }
        catch (AssetUnavailableException ex)
        {
            await DisplayAlertAsync("Error", "That book cannot be reserved, please try again later", "Ok");
        }
        catch (LibraryIDException ex)
        {
            await DisplayAlertAsync("Error", "A book could not be found with that id", "ok");
        }
        catch
        {
            await DisplayAlertAsync("Error", "An unknown error has occured, please contact someone who knows computers maybe", "Maybe?");
        }


    }

    /// <summary>
    /// Return book
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    public async void OnReturnBook(object sender, EventArgs e)
    {
        try
        {
            LibraryAsset selectedAsset = (LibraryAsset)_colAssets.SelectedItem;
            int assetID = selectedAsset.LibID;

            (TimeSpan latePeriod, int lateDays, decimal lateFee) = _book.ReturnBook(assetID);

            if (lateDays != null)
            {
                await DisplayAlertAsync("Completed", $"Book (ID: {assetID}) returned successfully", "Ok");
            }
            else
            {
                await DisplayAlertAsync("Returned late", $"Returned {lateDays} days late! Late fee: ${lateFee}.", "Aww");
            }
        }
        catch
        {

        }
    }

    /// <summary>
    /// Search for a book function
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public async void OnSearchByTitle(object sender, EventArgs e)
    {
        try
        {
            Book foundBook = _library.FindBookByName(_entTitle.Text);

            _book = foundBook;

            ObservableCollection<LibraryAsset> booksList = new ObservableCollection<LibraryAsset>(_book.Assets);
            _colAssets.ItemsSource = booksList;

            if (foundBook != null)
            {
                await DisplayAlertAsync("Success!", "Book was found", "Ok");
            } else
            {
                await DisplayAlertAsync("No results", "No results were found with that title.", "Ok");
            }
        }
        catch (InvalidCastException ex)
        {
            await DisplayAlertAsync("Error", "No book selected, try again", "Ok");
        }

    }

    public async void OnSearchByISBN(object sender, EventArgs e)
    {
        try
        {
            Book foundBook = _library.FindBookByISBN(_entISBN.Text);

            _book = foundBook;

            ObservableCollection<LibraryAsset> booksList = new ObservableCollection<LibraryAsset>(_book.Assets);
            _colAssets.ItemsSource = booksList;

            if (foundBook != null)
            {
                await DisplayAlertAsync("Success!", "Book was found", "Ok");
            }
            else
            {
                await DisplayAlertAsync("No results", "No results were found with that ISBN.", "Ok");
            }
        }
        catch (InvalidCastException ex)
        {
            await DisplayAlertAsync("Error", "No book selected, try again", "Ok");
        }
    }



    public void UpdateAssets()
    {
        _colAssets.ItemsSource = _book.Assets;
    }
}