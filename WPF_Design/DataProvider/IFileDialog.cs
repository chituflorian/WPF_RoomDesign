
namespace WPF_Design.DataProvider
{
    public interface IFileDialog
    {
        string InitialDirectory { get; set; }
        string DefaultExt { get; set; }
        string Filter { get; set; }
        string FileName { get; set; }
        bool ShowDialog();
    }
}
