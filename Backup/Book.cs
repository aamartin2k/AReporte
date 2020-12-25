using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorBooks
{
    public class Book
    {
        private string m_title;
        private string m_publisher;
        private float m_listPrice;

        public Book(string title, string publisher, float listPrice)
        {
            m_title = title;
            m_publisher = publisher;
            m_listPrice = listPrice;
        }

        public string Title
        {
            get { return m_title; }
            set { m_title = value; }
        }

        public string Publisher
        {
            get { return m_publisher; }
            set { m_publisher = value; }
        }

        public float ListPrice
        {
            get { return m_listPrice; }
            set { m_listPrice = value; }
        }
    }
}
