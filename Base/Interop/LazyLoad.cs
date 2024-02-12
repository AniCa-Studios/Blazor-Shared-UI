using Microsoft.JSInterop;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Loader;
using System.Reflection;

namespace Base.Interop
{
    public class LazyLoad
    {
        private readonly IJSRuntime _jsRuntime;

        public LazyLoad(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public Task AddLink(string id, string style, string place = "head")
        {
            try
            {
                _jsRuntime.InvokeVoidAsync("Base.Interop.addLink", id, style, place);
                return Task.CompletedTask;
            }
            catch(Exception ex) 
            {
                return Task.FromException(ex);
            }
        }

        public async Task<Type?> LoadComponent(string package, string component)
        {
            try
            {
                string path = Directory.GetCurrentDirectory();
                if (!File.Exists($"{path}/{package}.dll"))
                {
                    path = $"{path}/bin/Debug/net8.0";
                }
                Stream stream = File.OpenRead($"{path}/{package}.dll");
                Assembly assembly = AssemblyLoadContext.Default.LoadFromStream(stream);
                Type? componentType = assembly.GetType(package + "." + component);
                if (componentType != null)
                {
                    await AddLink(package, $"/{package}/{package}.styles.css");
                }
                return componentType;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
