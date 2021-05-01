namespace Ex04.Menus.Delegates
{
    public abstract class MenuItem
    {
        protected string m_HeaderName;
        protected SubMenu m_PreMenu;

        protected MenuItem(string i_HeaderName)
        {
            m_HeaderName = i_HeaderName;
        }

        public abstract void DoWhenChosen();

        public string Name
        {
            get
            {
                return m_HeaderName;
            }
        }

        public SubMenu PreMenu
        {
            get
            {
                return m_PreMenu;
            }

            set
            {
                m_PreMenu = value;
            }
        }
    }
}
