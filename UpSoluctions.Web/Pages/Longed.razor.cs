using MudBlazor;

namespace UpSoluctions.Web.Pages
{
    public partial class Longed
    {
        bool open = false;
        bool dense = false;
        bool preserveOpenState = false;
        Breakpoint breakpoint = Breakpoint.Lg;
        DrawerClipMode clipMode = DrawerClipMode.Always;

        void ToggleDrawer()
        {
            open = !open;
        }
    }
}
