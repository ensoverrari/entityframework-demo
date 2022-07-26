using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTKEntityFrameworkDemo
{
    //İngilizce karşılığı ‘Attributes’ olan öznitelikler, başlıca olarak sınıf, tür, fonksiyon gibi programlama ögelerine
    //açıklama eklemek için ve bu açıklamaları bildirim olarak görüntülemenize olanak tanır.
    //Tek görevi bununla sınırlı kalmamakla birlikte belirtildiği ögenin çalışma alanını kısıtlayabiliyor.
    //Ayrıca belirtilen ögede ‘Değişken’ ile de çalışabiliyorsunuz.

    class RequiredPropertyAttribute :Attribute
    {

    }
}
