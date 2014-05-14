using System;

namespace OefeningenLogo
{
    public interface IGeneratePdfs
    {
        void AddLine(string line);
        void Write();
        void InitializePage(DateTime datum);
    }
}