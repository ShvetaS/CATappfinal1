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
    public partial class Page3 : PhoneApplicationPage, INotifyPropertyChanged
    {
        private CatAppDataContext catAppDB;
        public static string DBConnectionString = "Data Source=isostore:/catappdb.sdf";
      //  public Int64 op;
        public Page3()
        {
            InitializeComponent();
            // Connect to the database and instantiate data context.
            catAppDB = new CatAppDataContext(DBConnectionString);

            // Data context and observable collection are children of the main page.
            this.DataContext = this;

            


        }
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify the app that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion



        private ObservableCollection<Question> _ques;
        public ObservableCollection<Question> Questions
        {
            get
            {
                return _ques;
            }
            set
            {
                if (_ques != value)
                {
                    _ques = value;
                    NotifyPropertyChanged("Questions");
                }
            }
        }

        private ObservableCollection<Option> _opts;
        public ObservableCollection<Option> Options
        {
            get
            {
                return _opts;
            }
            set
            {
                if (_opts != value)
                {
                    _opts = value;
                    NotifyPropertyChanged("Options");
                }
            }
        }
        private ObservableCollection<Category> _cats;
          public ObservableCollection<Category> Categories
        {
            get
            {
                return _cats;
            }
            set
            {
                if (_cats != value)
                {
                    _cats = value;
                    NotifyPropertyChanged("Categories");
                }
            }
        }

          private ObservableCollection<Question_category> _quecats;
          public ObservableCollection<Question_category> Question_categories
          {
              get
              {
                  return _quecats;
              }
              set
              {
                  if (_quecats != value)
                  {
                      _quecats = value;
                      NotifyPropertyChanged("Question_categories");
                  }
              }
          }

         
          protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
          {
              IDictionary<string, string> x = this.NavigationContext.QueryString;
              String a = Convert.ToString(x["selectedValue"]);
              textBox1.Text = a.ToString();
              base.OnNavigatedTo(e);
              
          }

          

         //for displaying options and questions of specific category
          public void display()
          {

              string s = textBox1.Text;
              long l;
              long.TryParse(s, out l);

              var q = (from Question qs1 in catAppDB.Questions
                       join Question_category qs2 in catAppDB.Question_categories on qs1._id equals qs2.Q_id
                       where qs2.C_id == l
                       select qs1).Count();
              var q1 = from Question qs1 in catAppDB.Questions
                       join Question_category qs2 in catAppDB.Question_categories on qs1._id equals qs2.Q_id
                       where qs2.C_id == l
                       select qs1;
              Questions = new ObservableCollection<Question>(q1);

  
             
              var v = Questions.ToList();
              int count = 1;
              string s1;
              long l1;

              for (int i = 0; i < q;i++ )
              {
                  PivotItem pi = new PivotItem();
                  pi.Header = string.Format("Q {0}", count);
                  Opt puc = new Opt();
                  // s2 = qq.Content.ToString();
                  puc.DataContext = v[i];

                  pi.Content = puc;
                
                  s1 =v[i]._id.ToString();
                  long.TryParse(s1, out l1);

                   fun2(l, l1);
                  fun1(l1, l);

                  pivot1.Items.Add(pi);


                  count++;
              }
          
          }
         //query for fetching options
          public void fun1(long qid,long cid)
          {
              
              var v = from Option op in catAppDB.Options
                      join Question_category qc in catAppDB.Question_categories on op.Q_id equals qc.Q_id
                      where op.Q_id == qid && qc.C_id == cid
                      select op;
              Options = new ObservableCollection<Option>(v);
          }
         //query for question
          public void fun2(long cid,long qid)
          {
              var q1 = from Question qs1 in catAppDB.Questions
                       join Question_category qs2 in catAppDB.Question_categories on qs1._id equals qs2.Q_id
                       where qs2.C_id == cid && qs1._id == qid
                       select qs1;
              Questions = new ObservableCollection<Question>(q1);

          }

        

       

          private void listBox1_Loaded(object sender, RoutedEventArgs e)
          {
              display();
          }
    }
}