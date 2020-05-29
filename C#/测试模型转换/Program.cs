using System.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json;
using AutoMapper;

namespace 测试模型转换
{
    /// <summary>
    /// 数据模型
    /// </summary>
    public class TestEntity
    {
        public string TextInfo { get; set; }
        public int Num { get; set; }
        public DateTime DateTime { get; set; }
    }
    /// <summary>
    /// DTO模型
    /// </summary>
    public class TestEntityDto
    {
        public string TextInfo { get; set; }
        public int Num { get; set; }
        public DateTime DateTime { get; set; }
    }
    public static class AutoMapExt
    {
        /// <summary>
        ///  类型映射,默认字段名字一一对应
        /// </summary>
        /// <typeparam name="TDestination">转化之后的model，可以理解为viewmodel</typeparam>
        /// <typeparam name="TSource">要被转化的实体，Entity</typeparam>
        /// <param name="source">可以使用这个扩展方法的类型，任何引用类型</param>
        /// <returns>转化之后的实体</returns>
        public static TDestination MapTo<TSource, TDestination>(this TSource source)
            where TDestination : class
            where TSource : class
        {
            var type = typeof(TSource);

            if (source == null) return default(TDestination);
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            var mapper = config.CreateMapper();
            return mapper.Map<TDestination>(source);
        }
        public static List<TDestination> MapListTo<TSource, TDestination>(this List<TSource> source)
            where TDestination : class
            where TSource : class
        {
            var type = typeof(TSource);

            if (source == null) return null;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            var mapper = config.CreateMapper();
            return mapper.Map<List<TSource>,List<TDestination>>(source);
        }
    }
    class Program
    {
        #region 获取构造数据
        private static TestEntity GetEntity()
        {
            Random random = new Random();
            return new TestEntity
            {
                Num = random.Next(int.MaxValue - 10000000, int.MaxValue),
                TextInfo = random.Next(int.MaxValue - 10000000, int.MaxValue).ToString(),
                DateTime = DateTime.Now
            };
        }
        private static List<TestEntity> GetEntities(int num)
        {
            List<TestEntity> list = new List<TestEntity>();
            for (int i = 0; i < num; i++)
            {
                list.Add(GetEntity());
            }
            return list;
        }
        #endregion
        #region 测试Json方法
        private static IEnumerable<TestEntityDto> TestJson(List<TestEntity> list)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var data = list.Select(a => TestJson(a)).ToList();
            stopwatch.Stop();
            Console.WriteLine($"{list.Count}个：Json转换模式需要时间是:{stopwatch.Elapsed.TotalMilliseconds}");
            return data;
        }
        private static TestEntityDto TestJson(TestEntity entity)
        {
            string jsonData = JsonConvert.SerializeObject(entity);
            return JsonConvert.DeserializeObject<TestEntityDto>(jsonData);
        }

        #endregion


        #region 自己赋值获取方法
        private static IEnumerable<TestEntityDto> TestBase(List<TestEntity> list)
        {

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var data = list.Select(a => new TestEntityDto()
            {
                TextInfo = a.TextInfo,
                Num = a.Num,
                DateTime = a.DateTime
            }).ToList();
            stopwatch.Stop();
            Console.WriteLine($"{list.Count}个：Base转换模式需要时间是:{stopwatch.Elapsed.TotalMilliseconds}");
            return data;
        }

        #endregion
        #region 使用AutoMapper
        private static IEnumerable<TestEntityDto> TestAutoMapper(List<TestEntity> list)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TestEntity, TestEntityDto>());
            var mapper = config.CreateMapper();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // var data = list.Select(a =>
            // {

            //     return mapper.Map<TestEntityDto>(a);
            //     //return a.MapTo<TestEntity, TestEntityDto>();
            // }
            // ).ToList();
            var data=list.MapListTo<TestEntity, TestEntityDto>();
            stopwatch.Stop();
            Console.WriteLine($"{list.Count}个：Map转换模式需要时间是:{stopwatch.Elapsed.TotalMilliseconds}");
            return data;
        }
        #endregion


        static void Main(string[] args)
        {
            var list = GetEntities(100);
            TestBase(list);
            TestJson(list);
            TestAutoMapper(list);
            

        }
    }
}
