using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Tensorflow;
using Tensorflow.Keras;
using Tensorflow.Keras.Engine;
using Tensorflow.Keras.Utils;


namespace ImageClassificationNote
{
    class ImageClassificationFolder
    {
        //public string ModelPath { get; set; }
        //public string LabelPath { get; set; }
        //public float TestingPercentage { get; set; } = 0.2f;

        public string WeightsPath { get; set; }
        public string DataDir { get; set; }
        public float ValidationPercentage { get; set; } = 0.1f;

        public string BaseFolder { get; set; }
        public int BatchSize { get; set; } = 1;


        IDatasetV2 trainData = null;
        IDatasetV2 validationData = null;


        public ImageClassificationFolder()
        {
            BaseFolder = "";
            DataDir = "";
            WeightsPath = "model.ckpt";
        }


    }
}
