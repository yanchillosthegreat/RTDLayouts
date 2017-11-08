using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace RTDLayouts.Controls
{
    public partial class StepsBarButton
    {
        #region Index Property

        public int Index
        {
            get => (int)GetValue(IndexProperty);
            set => SetValue(IndexProperty, value);
        }

        public static readonly DependencyProperty IndexProperty =
            DependencyProperty.Register("Index", typeof(int), typeof(StepsBarButton), new PropertyMetadata(0));

        #endregion

        #region Position Property

        public Position Position
        {
            get => (Position)GetValue(PositionProperty);
            set => SetValue(PositionProperty, value);
        }

        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(Position), typeof(StepsBarButton), new PropertyMetadata(Position.First));

        #endregion

        #region LifeState Property

        public LifeState LifeState
        {
            get => (LifeState)GetValue(LifeStateProperty);
            set => SetValue(LifeStateProperty, value);
        }

        public static readonly DependencyProperty LifeStateProperty =
            DependencyProperty.Register("LifeState", typeof(LifeState), typeof(StepsBarButton), new PropertyMetadata(LifeState.Next));

        #endregion
    }
}
