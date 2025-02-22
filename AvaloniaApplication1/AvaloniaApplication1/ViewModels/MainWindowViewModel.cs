using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvaloniaApplication1.ViewModels
{
   public class MainWindowViewModel:ViewModelBase
    {
        public ICommand BuyMusicCommand { get; }

        public MainWindowViewModel()
        {
            ShowDialog = new Interaction<MusicStoreViewModel, AlbumViewModel?>();
            //BuyMusicCommand = ReactiveCommand.Create(() =>
            //{
            //    // 当按钮被点击时，这里的代码将被执行。
            //    Debug.WriteLine("购买音乐");
            //});
            BuyMusicCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var store = new MusicStoreViewModel();

                var result = await ShowDialog.Handle(store);
            });
        }
        public Interaction<MusicStoreViewModel, AlbumViewModel?> ShowDialog { get; }
    }
}
