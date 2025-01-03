
namespace EscapeRoom
{
    public partial class MainPage : ContentPage
    {
        private int heart = 3;

        public MainPage()
        {
            InitializeComponent();
        }

        private void UpdateHeartsVisibility()
        {
            switch (heart)
            {
                case 3:
                    Heart1.IsVisible = true;
                    Heart2.IsVisible = true;
                    Heart3.IsVisible = true;
                    break;

                case 2:
                    Heart1.IsVisible = true;
                    Heart2.IsVisible = true;
                    Heart3.IsVisible = false;
                    break;

                case 1:
                    Heart1.IsVisible = true;
                    Heart2.IsVisible = false;
                    Heart3.IsVisible = false;
                    break;

                case 0:
                    Heart1.IsVisible = false;
                    Heart2.IsVisible = false;
                    Heart3.IsVisible = false;
                    break;
            }
        }

        private void StartBtn(object sender, EventArgs e)
        {
            UpdateHeartsVisibility();
            HeartsLayout.IsVisible = true;
            Room.IsVisible = true;
            Clue1Btn.IsVisible = true;
            Start.IsVisible = false;
            EscapeRoom.IsVisible = false;

        }

        private void AgainBtn(object sender, EventArgs e)
        {
            Again.IsVisible = false;
            Room.IsVisible = true;
          
            Lose.IsVisible = false;
            Start.IsVisible = true;
            EscapeRoom.IsVisible = true;
            Clue1Btn.IsVisible = false; 
            Room.Source = "room1.png";
            heart = 3;
        }
        private void ToggleVisibility(params VisualElement[] elements)
        {
            foreach (var element in elements)
            {
                element.IsVisible = !element.IsVisible;
            }
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            ToggleVisibility(Quiz1, Input1, OpenDoor);
        }

        private void OnButtonClicked2(object sender, EventArgs e)
        {
            ToggleVisibility(Quiz2, Input2, OpenDoor2);
        }
        private void OnButtonClicked3(object sender, EventArgs e)
        {
            ToggleVisibility(Quiz3, Input3,OpenDoor3);
        }
        private void OnButtonClicked4(object sender, EventArgs e)
        {
            ToggleVisibility(Quiz4, Input4, OpenDoor4);
        }
        private void OnButtonClicked5(object sender, EventArgs e)
        {
            ToggleVisibility(Quiz5, Input5, OpenDoor5);
        }


        private void ClearInputFields(params Entry[] inputs)
        {
            foreach (var input in inputs)
            {
                input.Text = string.Empty;
            }
        }
        private void ChangeRoom(string userInput, string correctAnswer, string newRoomImage,
            params VisualElement[] elementsToToggle)
        {
            if (userInput.Trim().ToLower() == correctAnswer.ToLower())
            {
                Room.Source = newRoomImage;
                ToggleVisibility(elementsToToggle);
            }
            else if (string.IsNullOrWhiteSpace(userInput)) 
            { 
            }
            else
            {
                heart--;
                UpdateHeartsVisibility(); 

                if (heart == 0)
                {
                    foreach (var element in elementsToToggle)
                    {
                        element.IsVisible = false;
                    }
                    HeartLabel.IsVisible = false;
                    Lose.IsVisible = true;
                    Again.IsVisible = true;
                }
                else
                {
                    Lose.IsVisible = false;
                }
            }
        }

      
        private void OnChangeRoom(object sender, EventArgs e)
        {
            ChangeRoom(Input1.Text, "746", "room2.png", Quiz1, Input1, OpenDoor, Clue1Btn, Clue2Btn);
            ClearInputFields(Input1);
        }

        private void OnChangeRoom2(object sender, EventArgs e)
        {
            ChangeRoom(Input2.Text, "48", "room3.png", Quiz2, Input2, OpenDoor2,Clue2Btn, Clue3Btn);
            ClearInputFields(Input2);
        }

        private void OnChangeRoom3(object sender, EventArgs e)
        {
            ChangeRoom(Input3.Text, "Петър", "room4.png", Quiz3, Input3, OpenDoor3, Clue3Btn,Clue4Btn);
            ClearInputFields(Input3);
        }

        private void OnChangeRoom4(object sender, EventArgs e)
        {
            ChangeRoom(Input4.Text, "6", "room5.png", Quiz4, Input4, OpenDoor4, Clue4Btn,Clue5Btn);
            ClearInputFields(Input4);
        }

        private void OnChangeRoom5(object sender, EventArgs e)
        {
            ChangeRoom(Input5.Text, "Тайната е разкрита", "you_win.png", Quiz5, Input5, OpenDoor5, Clue5Btn,
            HeartsLayout, Again);
            ClearInputFields(Input5);
        }
    }
}
