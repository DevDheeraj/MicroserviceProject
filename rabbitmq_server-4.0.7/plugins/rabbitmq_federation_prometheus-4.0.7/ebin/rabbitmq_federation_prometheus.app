{application, 'rabbitmq_federation_prometheus', [
	{description, "Exposes rabbitmq_federation metrics to Prometheus"},
	{vsn, "4.0.7"},
	{id, "834a101"},
	{modules, ['rabbit_federation_prometheus_app','rabbit_federation_prometheus_collector','rabbit_federation_prometheus_sup']},
	{registered, [rabbitmq_federation_prometheus_sup]},
	{applications, [kernel,stdlib,rabbit_common,rabbit,rabbitmq_federation,rabbitmq_prometheus]},
	{optional_applications, []},
	{mod, {rabbit_federation_prometheus_app, []}},
	{env, []},
		{broker_version_requirements, []}
]}.