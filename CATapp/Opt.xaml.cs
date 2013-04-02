using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Navigation;


namespace CATapp
{
    public partial class Opt : PhoneApplicationPage
    {
        //             private CatAppDataContext catAppDB;
        //        public static string DBConnectionString = "Data Source=isostore:/catappdb.sdf";
        //      //  public Int64 op;
        public Opt()
        {
            InitializeComponent();
            //            // Connect to the database and instantiate data context.
            //            catAppDB = new CatAppDataContext(DBConnectionString);

            //            // Data context and observable collection are children of the main page.
            //            this.DataContext = this;



        }
        //        #region INotifyPropertyChanged Members

        //        public event PropertyChangedEventHandler PropertyChanged;

        //        // Used to notify the app that a property has changed.
        //        private void NotifyPropertyChanged(string propertyName)
        //        {
        //            if (PropertyChanged != null)
        //            {
        //                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //            }
        //        }
        //        #endregion



        //        private ObservableCollection<Question> _ques;
        //        public ObservableCollection<Question> Questions
        //        {
        //            get
        //            {
        //                return _ques;
        //            }
        //            set
        //            {
        //                if (_ques != value)
        //                {
        //                    _ques = value;
        //                    NotifyPropertyChanged("Questions");
        //                }
        //            }
        //        }

        //        private ObservableCollection<Option> _opts;
        //        public ObservableCollection<Option> Options
        //        {
        //            get
        //            {
        //                return _opts;
        //            }
        //            set
        //            {
        //                if (_opts != value)
        //                {
        //                    _opts = value;
        //                    NotifyPropertyChanged("Options");
        //                }
        //            }
        //        }
        //        private ObservableCollection<Category> _cats;
        //          public ObservableCollection<Category> Categories
        //        {
        //            get
        //            {
        //                return _cats;
        //            }
        //            set
        //            {
        //                if (_cats != value)
        //                {
        //                    _cats = value;
        //                    NotifyPropertyChanged("Categories");
        //                }
        //            }
        //        }

        //          private ObservableCollection<Question_category> _quecats;
        //          public ObservableCollection<Question_category> Question_categories
        //          {
        //              get
        //              {
        //                  return _quecats;
        //              }
        //              set
        //              {
        //                  if (_quecats != value)
        //                  {
        //                      _quecats = value;
        //                      NotifyPropertyChanged("Question_categories");
        //                  }
        //              }
        //          }


        //          public void fun1(long qid, long cid)
        //          {
        //              var v = from Option op in catAppDB.Options
        //                      join Question_category qc in catAppDB.Question_categories on op.Q_id equals qc.Q_id
        //                      where op.Q_id == qid && qc.C_id == cid
        //                      select op;
        //              Options = new ObservableCollection<Option>(v);
        //          }

        //          private void optListBox_Loaded(object sender, RoutedEventArgs e)
        //          {
        //              fun1(50, 103);
        //          }

        //}
    }
}