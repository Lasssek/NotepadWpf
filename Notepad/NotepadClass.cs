using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Notepad {

    class NotepadClass {

        public NotepadClass() { }

        private string currentWorkingFileName = "Bez Tytułu";
        private string currentWorkingDirectory = null;
        public double fontSize = 16;
        public string textData = "";
        private string textDataBufferBeforeSaved = "";

        public string GetCurrentWorkingDirectory() {

            return this.currentWorkingDirectory;
        }

        public void SetCurrentWorkingDirectory(string currentWorkingDirectory) {

            this.currentWorkingDirectory = currentWorkingDirectory;
        }

        public void setDataBufferBeforeSaved (string dataBuffer) {

            this.textDataBufferBeforeSaved = dataBuffer;
        }

        public string getDataBufferBeforeSaved () {

            return this.textDataBufferBeforeSaved;
        }

        public string getCurrentTextFileTitle () {

            string title = this.currentWorkingFileName + " - Notatnik";
            return title;
        }

        public string GetCurrentWorkingFileName() {

            return this.currentWorkingFileName;
        }

        public void SetCurrentWorkingFileName(string currentWorkingFileName) {

            this.currentWorkingFileName = currentWorkingFileName;
        }
    }
}
