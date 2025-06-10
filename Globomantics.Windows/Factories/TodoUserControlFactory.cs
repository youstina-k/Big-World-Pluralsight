using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Globomantics.Windows.UserControls;
using Globomantics.Windows.ViewModels;

namespace Globomantics.Windows.Factories
{
    public class TodoUserControlFactory
    {
        public static UserControl ChooseUserControl(ITodoViewModel viewModel)
        {
            UserControl onControl = viewModel switch
            {
                BugViewModel => new BugControl(viewModel),
                FeatureViewModel => new FeatureControl(viewModel),
            };
            return onControl;
        }
    }
}
