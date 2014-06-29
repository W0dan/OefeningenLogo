using System;

namespace OefeningenLogo.Backend
{
    public interface IGeneratePdfs
    {
        void AddLine(string line);
        void Write();
        void InitializePage(DateTime datum);
    }
}