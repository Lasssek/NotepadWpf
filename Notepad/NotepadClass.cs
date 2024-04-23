using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
    class NotepadClass
    {
        public NotepadClass()
        {

        }

        private string[] supportedFileExtensions;

        private string currentWorkingFileName = "Bez Tytułu";
        private string currentWorkingDirectory;

        public string GetCurrentWorkingDirectory()
        {
            return this.currentWorkingFileName;
        }
        public void SetCurrentWorkingDirectory(string currentWorkingDirectory)
        {
            this.currentWorkingDirectory = currentWorkingDirectory;
        }


        public string textData = "";
        public bool isSaved;
        private string textFileTitle;

        public string getCurrentTextFileTitle ()
        {
            string title = this.textFileTitle + " - Notatnik";
            return title;
        }


        public string GetCurrentWorkingFileName()
        {
            return this.currentWorkingFileName;
        }
        public void SetCurrentWorkingFileName(string currentWorkingFileName)
        {
            this.currentWorkingFileName = currentWorkingFileName;
        }

        public string[] GetSupportedFileExtenstions()
        {
            return this.supportedFileExtensions;
        }

        public void AddSupportedFileExtension(string fileExtension)
        {
            this.supportedFileExtensions.Append<string>(fileExtension);
        }

        public void SetSupportedFileExtentions(string[] fileExtensions)
        {
            this.supportedFileExtensions = fileExtensions;
        }
    }
}
