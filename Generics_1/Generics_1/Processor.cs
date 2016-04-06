namespace Generics_1
{
    public class Processor<TEngine, TEntity, TLogger>
    {
        public static ProcessorBuilderEntity<TCustomEngine> CreateEngine<TCustomEngine>()
        {
            return new ProcessorBuilderEntity<TCustomEngine>();
        }
    }

    public class ProcessorBuilderEntity<TCustomEngine>
    {
        public ProcessorBuilderLogger<TCustomEngine, TCustomEntity> For<TCustomEntity>()
        {
            return new ProcessorBuilderLogger<TCustomEngine, TCustomEntity>();
        }
    }

    public class ProcessorBuilderLogger<TEngine, TEntity>
    {
        public Processor<TEngine, TEntity, TLogger> With<TLogger>()
        {
            return new Processor<TEngine, TEntity, TLogger>();
        } 
    }
}
