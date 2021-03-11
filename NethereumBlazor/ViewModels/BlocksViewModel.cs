using System;
using System.Globalization;
using System.Linq;
using DynamicData;
using NethereumBlazor.Messages;
using NethereumBlazor.Services;
using ReactiveUI;

namespace NethereumBlazor.ViewModels
{
    public class BlocksViewModel : ReactiveObject
    {
        private  NewBlockProcessingService _newBlockProcessingService;
        private object _lockingObject = new object();
        private bool _loading;

        public BlocksViewModel(NewBlockProcessingService newBlockProcessingService)
        {
            _newBlockProcessingService = newBlockProcessingService;
            MessageBus.Current.Listen<UrlChanged>().Subscribe(x =>
                {
                    lock (_lockingObject)
                    {
                        Loading = true;
                        Blocks.Clear();
                    }
                }
            );
            Console.WriteLine("blocks count2: " + _newBlockProcessingService.Blocks.Items.ToList().Count);

            _newBlockProcessingService.Blocks.Connect().Subscribe(blockChanges =>
                {
                    Console.WriteLine("blocks count1: " + _newBlockProcessingService.Blocks.Items.ToList().Count);

                    lock (_lockingObject)
                    {
                        Loading = true;
                        Blocks.Edit(_ =>
                        {
                            Console.WriteLine("blocks count: " + _newBlockProcessingService.Blocks.Items.ToList().Count);

                            Blocks.Clear();
                            foreach (var block in _newBlockProcessingService.Blocks.Items)
                            {
                                Blocks.AddOrUpdate(new BlockViewModel(block));
                            }

                        });
                        Loading = false;
                    }
                }
            );
        }

        public SourceCache<BlockViewModel, string> Blocks { get; set; } = new SourceCache<BlockViewModel, string>(t => t.Number.ToString(CultureInfo.InvariantCulture));

        public bool Loading
        {
            get { return _loading; }
            set { this.RaiseAndSetIfChanged(ref _loading, value); }
        }
    }
}
