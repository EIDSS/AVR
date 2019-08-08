using System.Drawing;
using System.Windows.Forms;
using bv.common.Resources.Images;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace bv.WinTests.Core
{
    [TestClass]
    public class ResourceTest
    {
        [TestMethod]
        [Ignore]
        public void ImagesTest()
        {
            var image = ImagesStorage.Get("row");
            Assert.IsTrue(image != null);
            var frm = new Form
            {
                StartPosition = FormStartPosition.CenterScreen,
                Location = new Point(50, 50),
                Size = new Size(700, 600)
            };
            var pb = new PictureBox { Image = image, Location = new Point(10, 10), Size = new Size(60, 60) };
            frm.Controls.Add(pb);

            //var image2 = ImagesStorage.Get("armenia-flag");
            var image2 = ImagesStorage.Get("azerbaijan_flag_2_");
            var pb2 = new PictureBox { Image = image2, Location = new Point(10, 110), Size = new Size(60, 60) };
            frm.Controls.Add(pb2);

            frm.ShowDialog();
        }
    }
}
