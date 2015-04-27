using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Equivalency;

namespace __NAME__.IntegrationTests.Infrastructure
{
    class DefaultCompareConfig
    {
        public static EquivalencyAssertionOptions<T> Compare<T>(EquivalencyAssertionOptions<T> equivalencyAssertionOptions)
        {
            equivalencyAssertionOptions
                .Using(new DefaultMemberSelectionRule(typeof(T).Name));

            equivalencyAssertionOptions
                .Using<DateTime>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation, (int)1.Minutes().TotalMilliseconds))
                .WhenTypeIs<DateTime>();

            equivalencyAssertionOptions
                .IgnoringCyclicReferences();

            return equivalencyAssertionOptions;
        }
    }

    class DefaultMemberSelectionRule : IMemberSelectionRule
    {
        private readonly string _type;

        public DefaultMemberSelectionRule(string type)
        {
            _type = type;
        }

        public IEnumerable<SelectedMemberInfo> SelectMembers(IEnumerable<SelectedMemberInfo> selectedMembers, ISubjectInfo context, IEquivalencyAssertionOptions config)
        {
            var path = context.SelectedMemberPath.Split('.').ToList();
            var ignore = path.Contains(_type);

            return ignore 
                ? new SelectedMemberInfo[] { } 
                : selectedMembers;
        }
    }

}
