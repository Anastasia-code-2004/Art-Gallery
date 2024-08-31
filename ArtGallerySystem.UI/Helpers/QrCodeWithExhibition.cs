using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallerySystem.UI.Helpers
{
    public class QrCodeWithExhibition
    {
        public required ImageSource QrCode { get; set; }
        public required string ExhibitionName { get; set; }
        public bool IsUsed { get; set; }
    }

}
