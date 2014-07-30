using System;

namespace OefeningenLogo.Service
{
    public interface IGeneratePdfs
    {
        void AddLine(string line);
        void Write();
        void InitializePage(DateTime datum);
    }
}