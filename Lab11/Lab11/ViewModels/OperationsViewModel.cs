using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab11.ViewModels
{
    public class OperationsViewModel : ViewModelBase
    {
        #region Propiedades
        double valor1;
        public double Valor1
        {
            get { return valor1; }
            set
            {
                if (valor1 != value)
                {
                    valor1 = value;
                    OnPropertyChanged();
                }
            }
        }

        double valor2;
        public double Valor2
        {
            get { return valor2; }
            set
            {
                if (valor2 != value)
                {
                    valor2 = value;
                    OnPropertyChanged();
                }
            }
        }

        double suma;
        public double ResultSuma
        {
            get { return suma; }
            set
            {
                if (suma != value)
                {
                    suma = value;
                    OnPropertyChanged();
                }
            }
        }

        double resta;
        public double ResultResta
        {
            get { return resta; }
            set
            {
                if (resta != value)
                {
                    resta = value;
                    OnPropertyChanged();
                }
            }
        }

        double multiplicacion;
        public double ResultMultiplicacion
        {
            get { return multiplicacion; }
            set
            {
                if (multiplicacion != value)
                {
                    multiplicacion = value;
                    OnPropertyChanged();
                }
            }
        }

        double divicion;
        public double ResultDivicion
        {
            get { return divicion; }
            set
            {
                if (divicion != value)
                {
                    divicion = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #region Comandos
        public ICommand Sumar { protected set; get; }
        public ICommand Restar { protected set; get; }
        public ICommand Multiplicar { protected set; get; }
        public ICommand Divicion { protected set; get; }

        #endregion

        #region Constructor
        public OperationsViewModel() {
            Sumar = new Command(() =>
            {
                ResultSuma = Valor1 + Valor2;
            });

            Restar = new Command(() =>
            {
                ResultResta = Valor1 - Valor2;
            });

            Multiplicar = new Command(() => 
            {
                ResultMultiplicacion = Valor1 * Valor2;
            });

            Divicion = new Command(() =>
            {
                ResultDivicion = Valor1 / Valor2;
            });
        }
        #endregion
    }
}
