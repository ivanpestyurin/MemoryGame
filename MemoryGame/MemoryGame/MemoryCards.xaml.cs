using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MemoryGame
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemoryCards : ContentPage
    {
        private int currentGuessed = 0;
        private int seconds = 0;
        private int minutes = 0;
        private string m_DirPath;
        struct SourceImage
        {
            public string m_path;
            public int m_count;
            public SourceImage(string q, int w)
            {
                m_path = q;
                m_count = w;
            }
        }

        private int m_FirstImage = -1;
        private int m_SecondImage = -1;

        private SourceImage[] m_SourceImages = new SourceImage[9]
        {
            new SourceImage("image_1", 0),
            new SourceImage("image_2", 0),
            new SourceImage("image_3", 0),
            new SourceImage("image_4", 0),
            new SourceImage("image_5", 0),
            new SourceImage("image_6", 0),
            new SourceImage("image_7", 0),
            new SourceImage("image_8", 0),
            new SourceImage("image_9", 0)
        };

        private string[] vs = new string[18];
 
        public MemoryCards(string src)
        {
            InitializeComponent();
            m_DirPath = src;
            SetImages();
            Device.StartTimer(new TimeSpan(0, 0, 1), Callback);
        }

        private bool Callback()
        {
            if (seconds == 59)
            {
                seconds = 0;
                minutes++;
            }
            else
            {
                seconds++;
            }
            label_time.Text = minutes + ":" + string.Format("{0:d2}", seconds);
            return true;
        }

        private void SetImages()
        {
            Random random = new Random();
            for (int i = 0; i < 18; i++)
            {
                while (true)
                {
                    int n = random.Next(0, 9);
                    if (m_SourceImages[n].m_count != 2)
                    {
                        m_SourceImages[n].m_count++;
                        vs[i] = m_DirPath + "_" + m_SourceImages[n].m_path;
                        break;
                    }
                }
            }
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            if (m_FirstImage != -1 && m_SecondImage != -1)
                return;

            ImageButton imageButton = sender as ImageButton;
            int index = int.Parse(imageButton.StyleId.ToString().Substring(12));
            imageButton.Source = vs[index];

            if (m_FirstImage == -1)
            {
                m_FirstImage = index;
            }
            else if(index != m_FirstImage)
            {
                m_SecondImage = index;
            }

            if (m_FirstImage != m_SecondImage && m_FirstImage != -1 && m_SecondImage != -1)
            {
                Device.StartTimer(new TimeSpan(0,0,1), () =>
                {

                    if (vs[m_FirstImage] == vs[m_SecondImage])
                    {
                        imageButton.IsEnabled = false;
                        imageButton.IsVisible = false;
                        ImageButton imageButton1 = (ImageButton)cellsGrid.Children[m_FirstImage];
                        imageButton1.IsEnabled = false;
                        imageButton1.IsVisible = false;
                        currentGuessed++;

                        if (currentGuessed == 9)
                            ExitGame();

                    }
                    else
                    {
                        imageButton.Source = "Image";
                        ImageButton imageButton1 = (ImageButton)cellsGrid.Children[m_FirstImage];
                        imageButton1.Source = "Image";
                    }

                    m_FirstImage = -1;
                    m_SecondImage = -1;

                    return false;
                });
            }

        }

        private async void ExitGame()
        {
            await DisplayAlert("Congratulations!", "Well done!", "Thanks");
            await Navigation.PopModalAsync();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}