using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Perceptron
{
    class PerceptronMachine
    {
        public List<InputData> dataset;
        public Vector2d w;
        int count,stc;
        
        public PerceptronMachine(List<InputData> ds)
        {
            dataset = ds;
        }
        public void train()
        {
            w = new Vector2d(dataset[0].vector.x, dataset[0].vector.y);
            w = getWeight(w);
        }
        Vector2d getWeight(Vector2d w)
        {
            
                if(stc>dataset.Count*dataset.Count)
                {
                  MessageBox.Show("2d分類器，分類線會過中心點");
                  return w;
                }
                else if (count == dataset.Count - 1)
                {
                    stc++;
                    return w;
                }
                else if (Math.Sign(w.x * dataset[count].vector.x + w.y * dataset[count].vector.y) != Math.Sign(dataset[count].label))
                {
                    w.x = w.x + dataset[count].label * dataset[count].vector.x;
                    w.y = w.y + dataset[count].label * dataset[count].vector.y;
                    count = 0;
                    stc++;
                    return getWeight(w);
                }
                else
                {
                    count++;
                    return getWeight(w);
                }
        
            
        }
        
    }
}
