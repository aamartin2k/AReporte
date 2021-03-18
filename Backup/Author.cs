using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorBooks
{
    class Author
    {
        private int m_id;
        private string m_name;
        private List<Book> m_books;

        public Author(int id)
        {
            m_id = id;
        }

        public Author(string name, int id, List<Book> books)
        {
            m_name = name;
            m_id = id;
            m_books = books;
        }

        public int Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public List<Book> Books
        {
            get { return m_books; }
            set { m_books = value; }
        }
    }

    /// <summary>
    /// Comparer for sorting and searching Author collection by Id.
    /// </summary>
    class AuthorIdComparer : IComparer<Author>
    {
        public int Compare(Author author1, Author author2)
        {
            return author1.Id - author2.Id;
        }
    }
}
