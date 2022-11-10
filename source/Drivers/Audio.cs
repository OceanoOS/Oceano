using Cosmos.HAL.Drivers.PCI.Audio;
using Cosmos.System.Audio.IO;
using Cosmos.System.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oceano.Drivers
{
    public class Audio
    { 
        public static void PlayAudio(byte[] wawfile)
        {
            var mixer = new AudioMixer();
            var audioStream = MemoryAudioStream.FromWave(wawfile);
            var driver = AC97.Initialize(bufferSize: 4096);
            mixer.Streams.Add(audioStream);

            var audioManager = new AudioManager()
            {
                Stream = mixer,
                Output = driver
            };
            audioManager.Enable();
        }
    }
}
