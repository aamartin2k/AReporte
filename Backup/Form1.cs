using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Reporting.WinForms;

namespace AuthorBooks
{
    public partial class Form1 : Form
    {
        private List<Author> m_authors;

        public Form1()
        {
            InitAuthors();
            InitializeComponent();

            reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(LocalReport_SubreportProcessing);
        }

        private void InitAuthors()
        {
            m_authors = new List<Author>();

            List<Book> kernighanBooks = new List<Book>();
            kernighanBooks.Add(new Book("The C Programming Language", "Prentice Hall", 39.0F));
            kernighanBooks.Add(new Book("The Practice of Programming", "Addison-Wesley", 43.0F));

            m_authors.Add(new Author("Kernighan", 234, kernighanBooks));

            List<Book> grayBooks = new List<Book>();
            grayBooks.Add(new Book("Transaction Processing", "Morgan Kaufmann", 52.0F));

            m_authors.Add(new Author("Gray", 123, grayBooks));

            List<Book> wirthBooks = new List<Book>();
            wirthBooks.Add(new Book("Algorithms and Data Structures", "Prentice Hall", 37.0F));
            wirthBooks.Add(new Book("Compiler Construction", "Addison-Wesley", 43.0F));

            m_authors.Add(new Author("Wirth", 456, wirthBooks));

            //
            // Keep authors collection sorted so that we can binary search on it.
            //
            m_authors.Sort(new AuthorIdComparer());
        }

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            // Author id is passed to the subreport as a parameter.
            int authorId = int.Parse(e.Parameters[0].Values[0]);

            // Search for the author using the supplied id.
            // We can use binary search since we know authors collection is sorted by id.
            int index = m_authors.BinarySearch(new Author(authorId), new AuthorIdComparer());
            Debug.Assert(index >= 0);

            // Get the list of books by this author.
            List<Book> books = m_authors[index].Books;

            // Supply data for the subreport.
            e.DataSources.Add(new ReportDataSource("AuthorBooks_Book", books));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AuthorBindingSource.DataSource = m_authors;
            this.reportViewer1.RefreshReport();
        }
    }
}
