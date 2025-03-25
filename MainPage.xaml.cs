using System.ComponentModel;

namespace StudentGranding
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

    }
    public class MainViewModel : INotifyPropertyChanged
    {
        private double studentGrade;
        private string gradeIcon;
        private string gradeText;
        private Color backgroundColor;

        public event
            PropertyChangedEventHandler
            PropertyChanged;

        public double StudentGrade
        {
            get => studentGrade;
            set
            {
                studentGrade = value; OnPropertyChanged(nameof(StudentGrade));
                UpdateGrade();
            }
        }
        public string GradeIcon
        {
            get => gradeIcon;
            private set { gradeIcon = value; OnPropertyChanged(nameof(GradeIcon)); }
        }
        public string GradeText
        {
            get => gradeText;
            private set { gradeText = value; OnPropertyChanged(nameof(GradeText)); }

        }
        public Color BackgroundColor
        {
            get => backgroundColor;
            private set { backgroundColor = value; OnPropertyChanged(nameof(BackgroundColor)); }
        }
        private void UpdateGrade()
        {
            if (StudentGrade < 2.0)
            {
                BackgroundColor = Colors.Red;
                GradeIcon = "filed.png";
                GradeText = "Niedostateczny";
            }
            else if (StudentGrade <= 3.5)
            {
                BackgroundColor = Colors.Yellow;
                GradeIcon = "waring.png";
                GradeText = "Dostateczny";
            }
            else if (StudentGrade >= 3.5)
            {
                BackgroundColor = Colors.Green;
                GradeIcon = "succes.png";
                GradeText = "Bardzo dobry";
            }
            
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


