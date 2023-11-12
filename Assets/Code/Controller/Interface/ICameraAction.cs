namespace Code.Controller.Interface
{
    public interface ICameraAction
    {
        protected internal void CameraMove();

        protected internal void CameraFov(bool isRun);
    }
}