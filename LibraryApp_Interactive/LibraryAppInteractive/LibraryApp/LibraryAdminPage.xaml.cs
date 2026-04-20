using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryLibrary;

namespace LibraryAppInteractive;

public partial class LibraryAdminPage : ContentPage
{
    Library _library;
    public LibraryAdminPage(Library library)
    {        
        InitializeComponent();
        _library = library;
    }

    /// <summary>
    /// Handle registration of new book
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public async void OnRegisterBook(object sender, EventArgs e)
    {
        try
        {
            string bookName = _entName.Text;
            string ISBN = _entISBN.Text;
            int copies = int.Parse(_entCopies.Text);

            if (_pkrType.SelectedItem == null)
            {
                throw new ArgumentNullException("Book type has not been selected");
            }

            string bookType = (string)_pkrType.SelectedItem;
            BookType type;

            switch (bookType)
            {
                case "Paper":
                    type = BookType.Paper;
                    break;
                case "Digital":
                    type = BookType.Digital;
                    break;
                case "Audio":
                    type = BookType.Audio;
                    break;
                default:
                    throw new TypeException("That Book type does not exist");
            }

            string[] authorsArray = _entAuthors.Text.Split(',');

            Book newBook = _library.RegisterBook(bookName, ISBN, authorsArray, type, copies);

            OnDisplayBookAssets(newBook);

            await DisplayAlertAsync("Success", "Book has been registered", "Ok");
        }
        catch (InvalidCastException ex)
        {
            await DisplayAlertAsync("Error", "Please enter only numeric whole numbers in number of copies", "Ok");
        } 
        catch (ArgumentNullException ex)
        {
            await DisplayAlertAsync("Error", "Please select an asset type", "Ok");
        }
        catch (TypeException ex)
        {
            await DisplayAlertAsync("Error", "That book type is invalid, please try again", "ok");
        }
    }

    /// <summary>
    /// Show book assets, probably uses a search
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void OnDisplayBookAssets(Book book)
    { 
        ObservableCollection<LibraryAsset> assetList = new ObservableCollection<LibraryAsset>(book.Assets);
        _colAssets.ItemsSource = assetList;
    }
}