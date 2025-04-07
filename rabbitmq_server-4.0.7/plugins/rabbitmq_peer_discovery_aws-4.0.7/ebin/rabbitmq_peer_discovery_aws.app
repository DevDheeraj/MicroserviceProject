{application, 'rabbitmq_peer_discovery_aws', [
	{description, "AWS-based RabbitMQ peer discovery backend"},
	{vsn, "4.0.7"},
	{id, "834a101"},
	{modules, ['rabbit_peer_discovery_aws','rabbitmq_peer_discovery_aws']},
	{registered, []},
	{applications, [kernel,stdlib,inets,rabbit_common,rabbitmq_peer_discovery_common,rabbitmq_aws,rabbit]},
	{optional_applications, []},
	{env, []}
]}.