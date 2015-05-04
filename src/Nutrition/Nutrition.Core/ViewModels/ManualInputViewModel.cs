using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Nutrition.Core.ViewModels
{
    public class ManualInputViewModel : MvxViewModel
    {
        double? carbs;
        public double? Carbs
        {
            get { return carbs; }
            set 
            { 
                carbs = value; 
                RaisePropertyChanged(() => Carbs); 
                DoneCommand.RaiseCanExecuteChanged(); 
            }
        }

        double? sugarCarbs;
        public double? SugarCarbs
        {
            get { return sugarCarbs; }
            set 
            {
                sugarCarbs = value;
                RaisePropertyChanged(() => SugarCarbs);
                DoneCommand.RaiseCanExecuteChanged();
            }
        }

        double? protein;
        public double? Protein
        {
            get { return protein; }
            set 
            {
                protein = value; 
                RaisePropertyChanged(() => Protein);
                DoneCommand.RaiseCanExecuteChanged();
            }
        }

        double? fat;
        public double? Fat
        {
            get { return fat; }
            set 
            {
                fat = value; 
                RaisePropertyChanged(() => Fat);
                DoneCommand.RaiseCanExecuteChanged();
            }
        }

        double? saturatedFats;
        public double? SaturatedFats
        {
            get { return saturatedFats; }
            set 
            {
                saturatedFats = value; 
                RaisePropertyChanged(() => SaturatedFats);
                DoneCommand.RaiseCanExecuteChanged();
            }
        }

        double? salt;
        public double? Salt
        {
            get { return salt; }
            set 
            { 
                salt = value; 
                RaisePropertyChanged(() => Salt);
                DoneCommand.RaiseCanExecuteChanged();
            }
        }

        MvxCommand doneCommand;
        public MvxCommand DoneCommand
        {
            get
            {
                return doneCommand ??
                    (doneCommand = new MvxCommand(Done, IsValid));
            }
        }

        bool IsValid()
        {
            return
                Carbs.HasValue &&
                SugarCarbs.HasValue &&
                Protein.HasValue &&
                fat.HasValue &&
                SaturatedFats.HasValue &&
                Salt.HasValue;
        }

        void Done()
        {
            throw new NotImplementedException();
        }
    }
}
