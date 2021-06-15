using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_2_WPF.ViewModel
{
    public partial class MainViewModel : BaseViewModel
    {
        private async Task<Class_union> LoadData()
        {
            return await MainViewModel.
                    DeserializeElement<Class_union>(MainViewModel.DefaultPathToFile) ?? new Class_union();
        }
        public static async Task<bool> SerializeElement<T>(string filename,
            T listOfElements)
        {

            var result = await Task.Run(() =>
            {
                string TempError = "";
                try
                {
                    new DirectoryInfo("Data").Create();
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    using (TextWriter writer = new StreamWriter(filename, false))
                    {
                        ser.Serialize(writer, listOfElements);
                        writer.Close();
                        TempError = "";
                        return true;
                    }
                }
                catch (Exception exp)
                {
                    TempError = exp.Message ?? "";
                    return false;
                }
            });
            return result;
        }
        public static async Task<T> DeserializeElement<T>(string filename)
        {
            return await Task.Run(() => {
                string Error;
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    using (FileStream fs = new FileStream(filename, FileMode.Open))
                    {
                        T res = (T)serializer.Deserialize(fs);
                        Error = "";
                        return res;
                    }
                }
                catch (Exception exp)
                {
                    Error = exp.Message;
                    return default(T);
                }
            });
        }
    }
}
