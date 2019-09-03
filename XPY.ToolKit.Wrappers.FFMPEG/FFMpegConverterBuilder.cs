using System;
using System.Collections.Generic;
using System.Text;

namespace XPY.ToolKit.Wrappers.FFMPEG {
    /// <summary>
    /// FFMPEG轉檔器建構器
    /// </summary>
    public class FFMpegConverterBuilder {
        public string FFMpegPath { get; private set; } = "ffmpeg";


        public FFMpegConverterBuilder Path(string path) {
            FFMpegPath = path;
            return this;
        }

        public FFMpegConverterBuilder GenericOption(Action<GenericOption> option) {

            return this;
        }

        public FFMpegConverterBuilder VideoOption(Action<VideoOption> option) {

            return this;
        }

        public FFMpegConverterBuilder AudioOption(Action<AudioOption> option) {

            return this;
        }


        public FFMpegConverterBuilder AdvancedOption(Action<AdvancedOption> option) {

            return this;
        }



    }
}
